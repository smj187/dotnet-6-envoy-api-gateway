# API Gateway

This is a proof-of-concept implementation for an Envoy API Gateway implementation.

## Objectives

The following objectives are covered

- [x] Docker Compose setup
- [ ] Envoy as Reverse Proxy / Edge Router
- [ ] Envoy dynamic configuration (fs)
- [ ] Envoy local rate limiting
- [ ] Envoy external authZ
- [ ] Envoy with HTTPS
- [ ] Envpy with HTTP/2

## Running

```
docker-compose -f docker-compose-services.yaml up --build
docker-compose -f docker-compose-services.yaml down
```
