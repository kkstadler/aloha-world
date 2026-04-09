/* ============================================================
   Aloha World Dashboard — Client-side logic
   ============================================================ */

document.addEventListener('DOMContentLoaded', () => {

  // ── Collapsible cards ──────────────────────────────────
  document.querySelectorAll('.dash-card-header[data-bs-toggle="collapse"]')
    .forEach(header => {
      const targetId = header.getAttribute('data-bs-target');
      const target   = document.querySelector(targetId);
      const card     = header.closest('.dash-card');

      // Sync our custom collapsed class with Bootstrap
      if (target) {
        target.addEventListener('hide.bs.collapse', () => card.classList.add('collapsed'));
        target.addEventListener('show.bs.collapse', () => card.classList.remove('collapsed'));
      }
    });

  // ── Address map ────────────────────────────────────────
  const addrMapEl = document.getElementById('address-map');
  if (addrMapEl) {
    const lat = parseFloat(addrMapEl.dataset.lat);
    const lng = parseFloat(addrMapEl.dataset.lng);
    const lbl = addrMapEl.dataset.label || 'Location';

    const addrMap = L.map('address-map').setView([lat, lng], 15);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a>',
      maxZoom: 19
    }).addTo(addrMap);

    const icon = L.divIcon({
      html: '<i class="bi bi-geo-alt-fill" style="color:#dc3545;font-size:1.8rem"></i>',
      className: '',
      iconAnchor: [12, 28]
    });
    L.marker([lat, lng], { icon })
      .addTo(addrMap)
      .bindPopup(`<strong>${lbl}</strong>`);
  }

  // ── Country restriction map ────────────────────────────
  const restMapEl = document.getElementById('restriction-map');
  if (restMapEl && typeof RESTRICTION_DATA !== 'undefined') {

    const restrictionMap = L.map('restriction-map', {
      center: [45, 60],
      zoom: 3,
      minZoom: 2,
      maxZoom: 7
    });

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '&copy; OpenStreetMap contributors',
      opacity: 0.3
    }).addTo(restrictionMap);

    // Build lookup: ISO code → restriction data
    const lookup = {};
    RESTRICTION_DATA.forEach(c => { lookup[c.code] = c; });

    // Load world GeoJSON from CDN
    fetch('https://raw.githubusercontent.com/datasets/geo-countries/master/data/countries.geojson')
      .then(r => r.json())
      .then(geo => {
        // Filter to Europe + Asia only
        const europAsia = [
          'AL','AD','AM','AT','AZ','BY','BE','BA','BG','HR','CY','CZ','DK',
          'EE','FI','FR','GE','DE','GR','HU','IS','IE','IT','KZ','XK','LV',
          'LI','LT','LU','MT','MD','MC','ME','NL','NO','MK','PL','PT','RO',
          'RU','SM','RS','SK','SI','ES','SE','CH','TR','UA','GB','VA',
          // Asia
          'AF','AM','AZ','BH','BD','BT','BN','KH','CN','CY','GE','IN','ID',
          'IR','IQ','IL','JP','JO','KZ','KW','KG','LA','LB','MY','MV','MN',
          'MM','NP','KP','OM','PK','PS','PH','QA','SA','SG','KR','LK','SY',
          'TW','TJ','TH','TL','TR','TM','AE','UZ','VN','YE','HK','MO'
        ];

        const filtered = {
          type: 'FeatureCollection',
          features: geo.features.filter(f => {
            const code = f.properties.ISO_A2;
            return europAsia.includes(code);
          })
        };

        L.geoJSON(filtered, {
          style: feature => {
            const code = feature.properties.ISO_A2;
            const d    = lookup[code];
            return {
              fillColor: d ? d.color : '#cccccc',
              weight: 1,
              opacity: 1,
              color: '#555',
              fillOpacity: d ? 0.75 : 0.25
            };
          },
          onEachFeature: (feature, layer) => {
            const code = feature.properties.ISO_A2;
            const d    = lookup[code];
            const name = feature.properties.ADMIN || code;
            if (d) {
              layer.bindPopup(
                `<strong>${d.name}</strong><br>`+
                `<span class="badge" style="background:${d.color}">${d.label}</span><br>`+
                `<small>${d.notes}</small>`+
                (d.quarantine ? `<br><small><i class="bi bi-hourglass-split"></i> ${d.quarantine}-day quarantine</small>` : '')
              );
            } else {
              layer.bindPopup(`<strong>${name}</strong><br><small class="text-muted">No data</small>`);
            }
            layer.on('mouseover', () => layer.setStyle({ weight: 2, color: '#333', fillOpacity: 0.9 }));
            layer.on('mouseout',  () => layer.setStyle({ weight: 1, color: '#555', fillOpacity: d ? 0.75 : 0.25 }));
          }
        }).addTo(restrictionMap);
      })
      .catch(() => {
        restMapEl.innerHTML = '<div class="alert alert-warning m-3">Map data could not be loaded. Check network connection.</div>';
      });
  }
});
