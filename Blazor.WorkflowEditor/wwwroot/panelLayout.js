// Viewport width observer used by the editor to switch panels into a compact mode.
export function observeViewport(dotNetRef) {
    const notify = () => dotNetRef.invokeMethodAsync('OnViewportWidthChanged', window.innerWidth);
    const observer = new ResizeObserver(notify);
    observer.observe(document.documentElement);
    notify();
    return {
        disconnect() {
            observer.disconnect();
        }
    };
}
