echo "Hello, let's run docker container"
echo "docker build -t weather ."
docker build -t weather .
echo "docker run --rm -d  -p 443:443/tcp -p 80:80/tcp weather:latest"
docker run --rm -d  -p 443:443/tcp -p 80:80/tcp weather:latest
echo "Finished)"
cmd /k