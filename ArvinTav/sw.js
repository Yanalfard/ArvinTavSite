const staticCacheName = 'site-static-v6';
const dynamicCacheName = 'site-dynamic-v6';
const cacheMaxSize = 3;

const assets = [
    '/Content/Styles/Blog.min.css',
    '/Content/Styles/contactUs.min.css',
    '/Content/Styles/Home.min.css',
    '/Content/Styles/LoginRegister.min.css',
    '/Content/Styles/mainCategory.min.css',
    '/Content/Styles/SoftwarePackages.min.css',
    '/Content/UIkit/styles/uikit.min.css',
    '/Content/UIkit/styles/uikit.min.css',
    '/Content/bootstrap/css/bootstrap-rtl.css',
    '/Content/bootstrap/css/bootstrap.css',
    '/Content/bootstrap/css/bootstrap.min.css',
    '/Content/bootstrap/js/bootstrap.js',
    '/Content/bootstrap/js/bootstrap.min.js',
    '/Areas/Admin/style-rtl.css',
    '/Areas/Admin/style.css',
];

//install the service worker
self.addEventListener('install', (evt) => {
    evt.waitUntil(
        caches.open(staticCacheName).then(cache => {
            for (let item of assets) {
                cache.add(item);
            }
            //cache.addAll(assets);
        })
    )
});

// cache size limit 
const limitCacheSize = (name, size) => {
    caches.open(name).then(cache => {
        cache.keys().then(keys => {
            if (keys.length > size) {
                cache.delete(keys[0]).then(limitCacheSize(name, size));
            }
        })
    })
}

//activate service worker
self.addEventListener('activate', (evt) => {
    //console.log('Service worker activated');
    evt.waitUntil(
        caches.keys().then(keys => {
            return Promise.all(keys
                .filter(key => key !== staticCacheName && key !== dynamicCacheName)
                .map(key => caches.delete(key)))
        })
    )
});

//self.addEventListener('fetch', (evt) => {
//    //console.log('Fetch event', evt);
//    evt.respondWith(
//        caches.match(evt.request).then(cacheRes => {
//            if (!evt.request.url.includes('http')) return fetch(evt.request);
//            return cacheRes || fetch(evt.request).then(fetchRes => {
//                return caches.open(dynamicCacheName).then(cache => {
//                    cache.put(evt.request.url, fetchRes.clone());
//                    limitCacheSize(dynamicCacheName, cacheMaxSize);
//                    return fetchRes;
//                })
//            }).catch(() => {
//                if (evt.request.url.includes('/Home/') || evt.request.url.includes('/View/'))
//                    return caches.match('/StaticPage/404.html')
//            });
//        })
//    )
//})


self.addEventListener('fetch', (evt) => {
    //console.log('Fetch event', evt);
    evt.respondWith(
        caches.match(evt.request).then(cacheRes => {
            if (!evt.request.url.includes('http')) return fetch(evt.request);
            return cacheRes || fetch(evt.request);
        })
    )
})