// global-settings.js - Archivo para manejar ajustes globales
(function () {
    'use strict';

    // Configuraciones por defecto
    const defaultSettings = {
        theme: 'light',
        fontSize: 16,
        menuNotifications: true,
        mealReminders: true,
        reminderTime: 30,
        dietaryRestrictions: "",
        portionSize: 'medium',
        shareData: true
    };

    let currentSettings = { ...defaultSettings };

    // Función para cargar configuraciones
    function loadGlobalSettings() {
        try {
            // Intentar cargar desde localStorage primero
            const saved = localStorage.getItem('comedorSettings');
            if (saved) {
                currentSettings = { ...defaultSettings, ...JSON.parse(saved) };
                applyGlobalSettings();
                return;
            }

            // Si no hay en localStorage, cargar desde servidor
            fetch('/Ajustes/GetUserSettings', {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(response => {
                    if (response.ok) {
                        return response.json();
                    }
                    throw new Error('Error al cargar configuraciones');
                })
                .then(data => {
                    if (data && !data.error) {
                        currentSettings = { ...defaultSettings, ...data };
                        // Guardar en localStorage para futuras cargas
                        localStorage.setItem('comedorSettings', JSON.stringify(currentSettings));
                    }
                    applyGlobalSettings();
                })
                .catch(error => {
                    console.warn('No se pudieron cargar las configuraciones del servidor, usando defaults:', error);
                    applyGlobalSettings();
                });
        } catch (error) {
            console.error('Error al cargar configuraciones:', error);
            applyGlobalSettings();
        }
    }

    // Función para aplicar configuraciones globalmente
    function applyGlobalSettings() {
        // Aplicar tema
        document.documentElement.setAttribute('data-theme', currentSettings.theme);
        document.body.classList.toggle('dark-theme', currentSettings.theme === 'dark');

        // Aplicar tamaño de fuente
        document.documentElement.style.setProperty('--base-font-size', currentSettings.fontSize + 'px');
        document.body.style.fontSize = currentSettings.fontSize + 'px';

        // Aplicar clase para restricciones dietéticas si es necesario
        if (currentSettings.dietaryRestrictions) {
            document.body.setAttribute('data-dietary-restrictions', currentSettings.dietaryRestrictions);
        }

        // Disparar evento personalizado para que otras partes de la app puedan reaccionar
        window.dispatchEvent(new CustomEvent('settingsLoaded', {
            detail: currentSettings
        }));
    }

    // Función para actualizar configuraciones desde otra página
    function updateGlobalSettings(newSettings) {
        currentSettings = { ...currentSettings, ...newSettings };
        localStorage.setItem('comedorSettings', JSON.stringify(currentSettings));
        applyGlobalSettings();
    }

    // Función para obtener configuraciones actuales
    function getCurrentSettings() {
        return { ...currentSettings };
    }

    // Escuchar cambios en localStorage (para sincronizar entre pestañas)
    window.addEventListener('storage', function (e) {
        if (e.key === 'comedorSettings' && e.newValue) {
            try {
                const newSettings = JSON.parse(e.newValue);
                currentSettings = { ...defaultSettings, ...newSettings };
                applyGlobalSettings();
            } catch (error) {
                console.error('Error al sincronizar configuraciones entre pestañas:', error);
            }
        }
    });

    // Exponer funciones globalmente
    window.ComedorSettings = {
        load: loadGlobalSettings,
        update: updateGlobalSettings,
        get: getCurrentSettings,
        apply: applyGlobalSettings
    };

    // Cargar configuraciones cuando se carga el script
    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', loadGlobalSettings);
    } else {
        loadGlobalSettings();
    }

})();