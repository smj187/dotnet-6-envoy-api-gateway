# API Gateway

This is a proof-of-concept implementation for an Envoy API Gateway implementation.

## Objectives

The following objectives are covered

- [x] Docker Compose setup
- [x] Envoy as Reverse Proxy / Edge Router
- [x] Envoy dynamic configuration (fs)
- [x] Envoy local rate limiting
- [x] Envoy external authZ
- [ ] Envoy with HTTPS
- [ ] Envpy with HTTP/2

## Environment Setup

Run the services

```
docker-compose -f docker-compose-services.yaml up --build
docker-compose -f docker-compose-services.yaml down
```

Run envoy

```
docker-compose -f docker-compose-envoy.yaml up --build
docker-compose -f docker-compose-envoy.yaml down
```

## Test the gateway

Access public endpoint route (no authZ)

```
curl -X GET 'http://localhost:10000/public'
```

Access procted user endpoint route

```
curl -X GET 'http://localhost:10000/protected/user' --header 'Authorization: Bearer token3'
```

Invalid access to procted route (unauthroized response)

```
curl -X GET 'http://localhost:10000/protected/user' --header 'Authorization: Bearer token4'
```

Access private route

```
curl -X GET 'http://localhost:10000/protected/private' --header 'Authorization: Bearer token1'
```
