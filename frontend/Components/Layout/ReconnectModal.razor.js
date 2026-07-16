// JS colocado del componente ReconnectModal.
// Escucha el evento estándar del framework "components-reconnect-state-changed"
// y alterna clases sobre el <dialog> para reflejar el estado de la conexión.

const modal = document.getElementById('components-reconnect-modal');

if (modal) {
    if (typeof modal.showModal === 'function' && !modal.open) {
        // El dialog se abre/cierra según el estado; arranca cerrado.
    }

    document.addEventListener('components-reconnect-state-changed', (event) => {
        const state = event.detail?.state;

        modal.classList.remove(
            'components-reconnect-show',
            'components-reconnect-retrying',
            'components-reconnect-failed',
            'components-reconnect-rejected'
        );

        switch (state) {
            case 'show':
            case 'connecting':
                modal.classList.add('components-reconnect-show');
                if (typeof modal.showModal === 'function' && !modal.open) modal.showModal();
                break;
            case 'retrying':
                modal.classList.add('components-reconnect-retrying');
                if (typeof modal.showModal === 'function' && !modal.open) modal.showModal();
                break;
            case 'failed':
                modal.classList.add('components-reconnect-failed');
                break;
            case 'rejected':
                modal.classList.add('components-reconnect-rejected');
                break;
            case 'hide':
                if (typeof modal.close === 'function' && modal.open) modal.close();
                break;
        }
    });
}
