# API Gateway

This is a proof-of-concept implementation for an Envoy API Gateway implementation.

## Objectives

The following objectives are covered

- [x] Docker Compose setup
- [x] Docker Compose with HTTPS
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

## HTTPS

_Reference: [Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/core/additional-tools/self-signed-certificates-guide#create-a-self-signed-certificate)_

Create local self-signed certificates

```
dotnet dev-certs https -ep $env:APPDATA\ASP.NET\Https\PublicService.pfx -p crypticpassword && dotnet dev-certs https -ep $env:APPDATA\ASP.NET\Https\AuthService.pfx -p crypticpassword && dotnet dev-certs https -ep $env:APPDATA\ASP.NET\Https\ProtectedService.pfx -p crypticpassword
```

Configure secrets

```
dotnet user-secrets -p .\Services\PublicService\PublicService.csproj set "Kestrel:Certificates:Development:Password" "crypticpassword" && dotnet user-secrets -p .\Services\AuthService\AuthService.csproj set "Kestrel:Certificates:Development:Password" "crypticpassword" && dotnet user-secrets -p .\Services\ProtectedService\ProtectedService.csproj set "Kestrel:Certificates:Development:Password" "crypticpassword"
```

Clean up

```
dotnet user-secrets remove "Kestrel:Certificates:Development:Password" -p .\Services\PublicService\PublicService.csproj && dotnet user-secrets remove "Kestrel:Certificates:Development:Password" -p .\Services\AuthService\AuthService.csproj && dotnet user-secrets remove "Kestrel:Certificates:Development:Password" -p .\Services\ProtectedService\ProtectedService.csproj

dotnet dev-certs https --clean
```
