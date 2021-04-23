const cacheName = 'Todo-cache';

function swInstall(event) {
    event.waitUntil(
        caches.open(cacheName).then((cache) => {
            return cache.addAll([
                '/',
                '/todo/index',
                '/home/index',
                '/css/site.css',
                '/js/site.js'
            ]);
        })
    );
}
self.addEventListener('install', swInstall);

self.addEventListener('fetch', function (event) {
    event.respondWith(
        fetch(event.request)
            .then(function (networkResponse) {
                caches.open(cacheName).then((cache) => {
                    cache.add(event.request.url);
                });
                return networkResponse
            }).catch(function () {
                return caches.match(event.request)
            })
    )
})