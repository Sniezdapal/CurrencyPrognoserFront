FROM nginx:alpine AS final
WORKDIR /app
COPY bin/Release/netstandard2.1/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf
EXPOSE 3000