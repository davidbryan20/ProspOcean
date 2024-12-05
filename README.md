# **ProspOcean - README**

---

## 🌊 **Sobre o ProspOcean**
O **ProspOcean** é uma aplicação inovadora desenvolvida como parte do desafio **Global Solution FIAP**, com foco nas diretrizes de sustentabilidade da **ONU** e nos objetivos do **Oceans20**. A proposta é utilizar a tecnologia para mitigar os impactos ambientais das enchentes e promover a conservação dos oceanos, contribuindo para um futuro mais sustentável.

---

## 🚀 **Objetivo**
Criar uma solução que:
- **Monitore e mitigue impactos ambientais**: Utilizando sensores IoT para medir níveis e qualidade da água.
- **Classifique resíduos automaticamente**: Implementando algoritmos de visão computacional.
- **Promova a sustentabilidade**: Engajando comunidades e fornecendo ferramentas educacionais para a reciclagem eficiente e conservação marinha.

---

## 🌟 **Funcionalidades**
1. **Monitoramento em Tempo Real**  
   - Níveis e qualidade da água monitorados com sensores IoT.  
   - Dados apresentados em mapas interativos para rápida visualização.  

2. **Classificação de Resíduos**  
   - Algoritmos que detectam e categorizam resíduos automaticamente.  

3. **Educação Ambiental**  
   - Artigos, vídeos e infográficos para conscientizar usuários sobre práticas sustentáveis.  

4. **Engajamento Comunitário**  
   - Plataforma para campanhas de limpeza e eventos organizados por ONGs.  
   - Sistema de doações para apoiar iniciativas ambientais.  

5. **Conservação de Espécies Marinhas**  
   - Monitoramento de espécies utilizando análise de dados e inteligência artificial.  

6. **Relatórios de Incidentes**  
   - Usuários podem registrar problemas com descrição, localização e fotos.  

---

## 🔧 **Tecnologias Utilizadas**
### **Backend**
- **.NET 8** e **Java**: Desenvolvimento de APIs RESTful para suportar todas as funcionalidades.  
- **MongoDB** e **Oracle**: Bancos de dados para armazenamento eficiente.  
- **Swagger**: Documentação dos endpoints para facilitar a integração.  
- **Mensageria com Kafka**: Garantia de comunicação assíncrona.  
- **FluentValidation**: Validação de dados.  
- **ML.NET**: Treinamento de modelos para classificação de resíduos.  
- **Actuator e HealthCheck**: Monitoramento de APIs.  

### **Frontend**
- **Mobile App**: Desenvolvido com **React Native**, integrado às APIs RESTful.  

### **Infraestrutura**
- **Azure AI**: Para análises e previsões baseadas em dados.  
- **IoT**: Sensores para coleta de dados ambientais em tempo real.  

---

## 💼 **Contribuições**
### **Desenvolvedores**
- **Agatha Pires**  
- **Murilo Matos**  
- **Gabriel Lima**  
- **Giovanna Alvarez**  

### **Minhas Contribuições**
- Desenvolvimento da **API REST** em **.NET** e **Java**.  
- Implementação de algoritmos para classificação de resíduos.  
- Integração com sensores IoT e Azure AI.  
- Criação de endpoints documentados e validados para suporte às funcionalidades.

---

## 📚 **Como Executar**
### **Pré-requisitos**
- .NET SDK 8 ou superior  
- Java 17+  
- Node.js e npm/yarn  
- Docker (opcional)  

### **Passos**
1. Clone o repositório:  
   ```bash
   git clone https://github.com/davidbryan20/ProspOcean.git
   cd ProspOcean

2. Configure as variáveis de ambiente:  
   Crie um arquivo `.env` na raiz dos diretórios `backend/dotnet` e `backend/java`, conforme necessário, e adicione as configurações de conexão com os bancos de dados e serviços. Exemplo:  

   **Para .NET**:  
   ```env
   MongoDb__ConnectionString=mongodb://localhost:27017
   MongoDb__DatabaseName=ProspOcean
   Kafka__BootstrapServers=localhost:9092
   AzureAI__ApiKey=SUA_CHAVE_DO_AZURE

