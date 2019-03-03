set -ex

# SET THE FOLLOWING VARIABLES
# docker hub username
USERNAME=davidxchen
# image name
IMAGE=carparkserver

#dotnet build

docker build -t $USERNAME/$IMAGE:latest --build-arg APP_VER=alpha .

docker tag $USERNAME/$IMAGE:latest 0.1.1

# push it
docker push $USERNAME/$IMAGE:latest
docker push $USERNAME/$IMAGE:0.1.1