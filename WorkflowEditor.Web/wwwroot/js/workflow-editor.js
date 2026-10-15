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

// The toolbar reads the theme that is in effect: its button switches to the other one, and a reload
// restores the theme before the editor is rendered.
window.currentTheme = () => document.documentElement.getAttribute('data-theme') === 'dark' ? 'dark' : 'light';

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

// The unsaved schema is kept in the browser, so a reload of the page cannot lose the work: the page writes the
// draft shortly after the last edit, offers it back when the editor starts, and drops it once the workflow is
// saved or another one is opened.
const draftKey = 'workflow-editor-draft';

const warnBeforeUnload = (event) => {
    // The browser writes the question itself; returning a value is what older browsers need to show it.
    event.preventDefault();
    event.returnValue = '';
    return '';
};

window.saveDraft = (source) => {
    try {
        localStorage.setItem(draftKey, source);
    } catch {
        // Private browsing modes may not allow storage; the editor keeps working without a draft.
    }
};

window.loadDraft = () => {
    try {
        return localStorage.getItem(draftKey) ?? '';
    } catch {
        return '';
    }
};

window.clearDraft = () => {
    try {
        localStorage.removeItem(draftKey);
    } catch {
        // Nothing to drop when storage is not available.
    }
};

// The browser asks before a reload or a close only while the schema has unsaved changes.
window.setDirtyGuard = (dirty) => {
    window.removeEventListener('beforeunload', warnBeforeUnload);
    if (dirty) {
        window.addEventListener('beforeunload', warnBeforeUnload);
    }
};
