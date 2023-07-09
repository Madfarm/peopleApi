# Service Lifetimes

Transient - An instance of the service is created at every code request including each individual controller and HTTP request

> memory inefficient
> best for multi-threading and concurrency

Scoped - An instance of the service is created per HTTP request, multiple classes using the service inside of one request will use the same instance of the service

Singleton - An instance of the service is created when the application is run and is shared at between every object and request

> Can cause issues with concurrency and multi-threading
> memory efficient

Compare to Angular DI?
Another time perhaps