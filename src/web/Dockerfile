FROM node:12.16.1-alpine As builder
WORKDIR /usr/src/app
COPY web/package.json web/package-lock.json ./
RUN npm install
COPY ./web .
RUN npm run build --prod
FROM nginx:1.15.8-alpine
COPY --from=builder /usr/src/app/dist/web/ /usr/share/nginx/html