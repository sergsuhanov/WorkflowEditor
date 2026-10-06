window.downloadFileFromStream = async (fileName, streamReference) => {
    const content = await streamReference.arrayBuffer();
    const url = URL.createObjectURL(new Blob([content], { type: "application/xml;charset=utf-8" }));
    const link = document.createElement("a");
    link.href = url;
    link.download = fileName;
    link.click();
    link.remove();
    setTimeout(() => URL.revokeObjectURL(url), 1000);
};

// Theme switching: styles.dark.css only overrides the base sheet, so the base sheet has to stay
// enabled in both themes (otherwise ports, grid, badges and family accents disappear in the dark theme).
window.enableTheme = (theme) => {
    const light = document.getElementById('light');
    const dark = document.getElementById('dark');
    if (!light || !dark) {
        return;
    }

    light.disabled = false;
    dark.disabled = theme !== 'dark';

    //The application chrome (toolbar, alerts) is styled through this attribute, because the
    //theme style sheets are only toggled by the disabled flag.
    document.documentElement.setAttribute('data-theme', theme === 'dark' ? 'dark' : 'light');

    try {
        localStorage.setItem('workflow-editor-theme', theme);
    } catch {
        // Private browsing modes may not allow storage; the theme still applies for this session.
    }
};

// Restore the saved theme as early as possible to avoid a flash of the light theme.
(() => {
    try {
        const stored = localStorage.getItem('workflow-editor-theme');
        if (stored) {
            window.enableTheme(stored);
        }
    } catch {
        // Ignore unavailable storage.
    }
})();
