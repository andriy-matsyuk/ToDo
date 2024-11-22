FROM node:18 as build

WORKDIR /app

COPY package*.json ./

RUN npm install

COPY . .

ENV VITE_API_BASE_URL=http://localhost:7100

RUN npm run build

FROM nginx:alpine

COPY --from=build /app/dist /usr/share/nginx/html

# Expose port 80
EXPOSE 80

# Start nginx
CMD ["nginx", "-g", "daemon off;"]
