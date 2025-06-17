// Chart.js tarayıcıya importmap üzerinden yüklendiği için doğrudan kullanılabilir

const appContent = document.getElementById('app-content');
const navLinks = document.querySelectorAll('.nav-link');

const mockVehicles = [
    { id: 1, name: "EcoCruiser X", type: "Sedan", year: 2023, engineLiters: 1.5, horsepower: 150, weightKg: 1300, transmission: "Automatic", mpg: 35, l100km: 6.7 },
    { id: 2, name: "TerraHauler Z", type: "SUV", year: 2022, engineLiters: 3.0, horsepower: 280, weightKg: 2100, transmission: "Automatic", mpg: 22, l100km: 10.7 },
    { id: 3, name: "CityHopper S", type: "Hatchback", year: 2024, engineLiters: 1.2, horsepower: 110, weightKg: 1100, transmission: "Manual", mpg: 40, l100km: 5.9 },
    { id: 4, name: "WorkHorse Pro", type: "Truck", year: 2021, engineLiters: 5.2, horsepower: 350, weightKg: 2500, transmission: "Automatic", mpg: 15, l100km: 15.7 },
    { id: 5, name: "LuxuryLiner V", type: "Sedan", year: 2023, engineLiters: 2.5, horsepower: 220, weightKg: 1600, transmission: "Automatic", mpg: 28, l100km: 8.4 },
    { id: 6, name: "Sportster GT", type: "Coupe", year: 2024, engineLiters: 3.5, horsepower: 320, weightKg: 1550, transmission: "Automatic", mpg: 25, l100km: 9.4 },
    { id: 7, name: "UrbanMover E", type: "Van", year: 2022, engineLiters: 2.0, horsepower: 180, weightKg: 1900, transmission: "Automatic", mpg: 20, l100km: 11.8 }
];

let activeCharts = [];

// --- VIEW RENDERING FUNCTIONS (kısaltılmış versiyon) ---
function renderPredictionView() {
    clearCharts();
    appContent.innerHTML = <section class="view-section"><h2>Prediction View</h2></section>;
}

function renderAnalyticsView() {
    clearCharts();
    appContent.innerHTML = `
        <section class="view-section">
            <h2>Analytics View</h2>
            <canvas id="avgMpgByTypeChart"></canvas>
            <canvas id="horsepowerVsMpgChart"></canvas>
        </section>
    `;
    initAnalyticsCharts();
}

function renderComparisonView() {
    clearCharts();
    appContent.innerHTML = <section class="view-section"><h2>Comparison View</h2></section>;
}

function renderCarInfoView() {
    clearCharts();
    appContent.innerHTML = <section class="view-section"><h2>Car Info View</h2></section>;
}

function initAnalyticsCharts() {
    const types = [...new Set(mockVehicles.map(v => v.type))];
    const avgMpgByType = types.map(type => {
        const vehicles = mockVehicles.filter(v => v.type === type);
        const totalMpg = vehicles.reduce((sum, v) => sum + v.mpg, 0);
        return (totalMpg / vehicles.length).toFixed(1);
    });

    const ctx1 = document.getElementById('avgMpgByTypeChart').getContext('2d');
    activeCharts.push(new Chart(ctx1, {
        type: 'bar',
        data: {
            labels: types,
            datasets: [{
                label: 'Average MPG',
                data: avgMpgByType,
                backgroundColor: 'rgba(0, 229, 255, 0.6)',
                borderColor: 'rgba(0, 229, 255, 1)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: { labels: { color: '#444' } }
            },
            scales: {
                y: { beginAtZero: true },
                x: { ticks: { color: '#444' } }
            }
        }
    }));

    const hpVsMpgData = mockVehicles.map(v => ({ x: v.horsepower, y: v.mpg }));
    const ctx2 = document.getElementById('horsepowerVsMpgChart').getContext('2d');
    activeCharts.push(new Chart(ctx2, {
        type: 'scatter',
        data: {
            datasets: [{
                label: 'Horsepower vs MPG',
                data: hpVsMpgData,
                backgroundColor: 'rgba(75, 192, 192, 0.6)'
            }]
        },
        options: {
            responsive: true,
            scales: {
                x: { title: { display: true, text: 'HP' } },
                y: { title: { display: true, text: 'MPG' } }
            }
        }
    }));
}

function clearCharts() {
    activeCharts.forEach(chart => chart.destroy());
    activeCharts = [];
}

// --- ROUTING ---
function handleRouteChange() {
    const hash = window.location.hash || '#predict';
    const view = hash.substring(1);
    navLinks.forEach(link => {
        link.classList.toggle('active', link.dataset.view === view);
    });

    switch (view) {
        case 'predict': renderPredictionView(); break;
        case 'analytics': renderAnalyticsView(); break;
        case 'compare': renderComparisonView(); break;
        case 'car-info': renderCarInfoView(); break;
        default: renderPredictionView();
    }
}

// --- INITIALIZATION ---
document.addEventListener('DOMContentLoaded', () => {
    window.addEventListener('hashchange', handleRouteChange);
    handleRouteChange();
});
