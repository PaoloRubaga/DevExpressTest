// Gestione degli eventi di resize della finestra
let windowEventListeners = {};

function AddWindowResizeListener(objReference) {
    let eventListener = () => UpdateWindowSize(objReference);
    window.addEventListener("resize", eventListener);
    windowEventListeners[objReference] = eventListener;
}

function RemoveWindowResizeListener(objReference) {
    window.removeEventListener("resize", windowEventListeners[objReference]);
}

function UpdateWindowSize(objReference) {
    objReference.invokeMethodAsync("UpdateWindowSize", window.innerWidth, window.innerHeight);
}