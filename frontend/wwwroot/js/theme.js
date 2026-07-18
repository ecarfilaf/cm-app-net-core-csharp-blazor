window.mfTheme = {
    init: function () {
        const saved = localStorage.getItem('mf-theme') || 'light';
        document.documentElement.setAttribute('data-theme', saved);
    },
    current: function () {
        return document.documentElement.getAttribute('data-theme') || 'light';
    },
    toggle: function () {
        const next = this.current() === 'light' ? 'dark' : 'light';
        document.documentElement.setAttribute('data-theme', next);
        localStorage.setItem('mf-theme', next);
        return next;
    }
};

window.mfTheme.init();
