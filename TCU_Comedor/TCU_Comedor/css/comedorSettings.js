// comedorSettings.js - Incluir en todas las páginas
window.ComedorSettings = (function () {
    'use strict';

    let currentSettings = {
        theme: 'light',
        fontSize: 16,
        menuNotifications: true,
        mealReminders: true,
        reminderTime: 30,
        dietaryRestrictions: "",
        portionSize: 'medium',
        shareData: true
    };

    // Función para cargar configuraciones
    function loadSettings() {
        // Primero cargar desde localStorage para aplicación inmediata
        const localSettings = localStorage.getItem('comedorSettings');
        if (localSettings) {
            try {
                const parsed = JSON.parse(localSettings);
                currentSettings = { ...currentSettings, ...parsed };
                applySettings();
            } catch (e) {
                console.error('Error parsing local settings:', e);
            }
        }

        // Cargar desde servidor para sincronizar (solo si está autenticado)
        if (window.location.pathname !== '/Account/Login' && window.location.pathname !== '/Account/Register') {
            loadFromServer();
        }
    }

    // Cargar desde servidor
    function loadFromServer() {
        fetch('/Ajustes/GetUserSettings', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            }
        })
            .then(response => {
                if (response.ok) {
                    return response.json();
                }
                throw new Error('Error en servidor');
            })
            .then(data => {
                if (data && !data.error) {
                    currentSettings = { ...currentSettings, ...data };
                    localStorage.setItem('comedorSettings', JSON.stringify(currentSettings));
                    applySettings();
                }
            })
            .catch(error => {
                console.log('No se pudieron cargar configuraciones del servidor');
            });
    }

    // Aplicar configuraciones al DOM
    function applySettings() {
        const html = document.documentElement;
        const body = document.body;

        // Aplicar tema
        html.setAttribute('data-theme', currentSettings.theme);
        body.className = body.className.replace(/theme-\w+/g, '');
        body.classList.add(`theme-${currentSettings.theme}`);

        // Aplicar tamaño de fuente globalmente
        html.style.setProperty('--base-font-size', currentSettings.fontSize + 'px');
        body.style.fontSize = currentSettings.fontSize + 'px';

        // Aplicar estilos de tema
        if (currentSettings.theme === 'dark') {
            injectDarkThemeStyles();
        } else {
            removeDarkThemeStyles();
        }

        // Disparar evento para notificar cambios
        window.dispatchEvent(new CustomEvent('comedorSettingsChanged', {
            detail: currentSettings
        }));
    }

    // Inyectar estilos de tema oscuro
    function injectDarkThemeStyles() {
        let darkStyleSheet = document.getElementById('dark-theme-styles');

        if (!darkStyleSheet) {
            darkStyleSheet = document.createElement('style');
            darkStyleSheet.id = 'dark-theme-styles';
            document.head.appendChild(darkStyleSheet);
        }

        darkStyleSheet.textContent = `
            [data-theme="dark"] body {
                background-color: #121212 !important;
                color: #ffffff !important;
            }
            
            [data-theme="dark"] .navbar {
                background-color: #1f1f1f !important;
            }
            
            [data-theme="dark"] .navbar .nav-link {
                color: #ffffff !important;
            }
            
            [data-theme="dark"] .navbar .nav-link:hover {
                color: #ffc107 !important;
            }
            
            [data-theme="dark"] .block {
                background-color: #1f1f1f !important;
                color: #ffffff !important;
            }
            
            [data-theme="dark"] .heading {
                color: #ffffff !important;
            }
            
            [data-theme="dark"] .heading span {
                color: #ffc107 !important;
            }
            
            [data-theme="dark"] p {
                color: #cccccc !important;
            }
            
            [data-theme="dark"] #hero-area {
                filter: brightness(0.8);
            }
            
            [data-theme="dark"] .blog-img img,
            [data-theme="dark"] .blog-img-2 img {
                filter: brightness(0.9);
            }
            
            [data-theme="dark"] .pricing-list {
                background-color: #1f1f1f !important;
            }
            
            [data-theme="dark"] .pricing-list .item {
                border-color: #333333 !important;
            }
            
            [data-theme="dark"] .pricing-list .item h2 {
                color: #ffffff !important;
            }
            
            [data-theme="dark"] .pricing-list .item span {
                color: #ffc107 !important;
            }
            
            [data-theme="dark"] .border-bottom {
                border-color: #333333 !important;
            }
            
            [data-theme="dark"] #slider,
            [data-theme="dark"] #about-us,
            [data-theme="dark"] #blog,
            [data-theme="dark"] #price {
                background-color: #121212 !important;
            }

            /* Ajustes adicionales para mejor contraste */
            [data-theme="dark"] .container {
                background-color: transparent !important;
            }
            
            [data-theme="dark"] .wow {
                color: inherit !important;
            }
        `;
    }

    // Remover estilos de tema oscuro
    function removeDarkThemeStyles() {
        const darkStyleSheet = document.getElementById('dark-theme-styles');
        if (darkStyleSheet) {
            darkStyleSheet.remove();
        }
    }

    // Función pública para actualizar configuraciones
    function updateSettings(newSettings) {
        currentSettings = { ...currentSettings, ...newSettings };
        localStorage.setItem('comedorSettings', JSON.stringify(currentSettings));
        applySettings();
    }

    // Función pública para obtener configuraciones
    function getSettings() {
        return { ...currentSettings };
    }

    // Inicialización cuando el DOM esté listo
    function initialize() {
        if (document.readyState === 'loading') {
            document.addEventListener('DOMContentLoaded', loadSettings);
        } else {
            loadSettings();
        }
    }

    // API pública
    return {
        initialize: initialize,
        update: updateSettings,
        get: getSettings,
        load: loadSettings,
        apply: applySettings
    };
})();

// Auto-inicializar cuando se carga el script
ComedorSettings.initialize();