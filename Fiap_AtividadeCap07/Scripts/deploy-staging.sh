echo "Iniciando deploy em staging..."

ssh usuario@staging-server << 'EOF'
cd /caminho/projeto/
git pull origin staging
docker-compose down
docker-compose up -d --build
EOF

echo "Deploy em staging finalizado."