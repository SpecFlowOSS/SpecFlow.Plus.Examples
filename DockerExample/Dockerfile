FROM mcr.microsoft.com/dotnet/core/sdk:3.0.100-alpine3.9

WORKDIR /src

COPY . /src

# install Mono
RUN echo "@testing http://dl-4.alpinelinux.org/alpine/edge/testing" >> /etc/apk/repositories \
    && apk update \
    && apk add mono@testing \
    && rm -rf /var/cache/apk/*

# build solution
RUN dotnet build /src/*.sln -v n

# execute
CMD dotnet test /src/*.sln -v n --no-restore --no-build