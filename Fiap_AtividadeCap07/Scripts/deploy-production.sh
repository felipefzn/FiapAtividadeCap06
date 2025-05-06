echo "Iniciando deploy em produção..."

ssh usuario@production-server << 'EOF'
cd /caminho/projeto/
git pull origin master
docker-compose down
docker-compose up -d --build
EOF

echo "Deploy em produção finalizado."