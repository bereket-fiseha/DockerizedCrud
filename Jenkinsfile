pipeline {
    agent any

    stages {
 
        stage('Restore packages'){
           steps{
               sh 'dotnet restore DockerizedCrud.csproj'
            }
         }
        stage('Clean'){
           steps{
               sh 'dotnet clean DockerizedCrud.csproj --configuration Release'
            }
         }
        stage('Build'){
           steps{
               sh 'dotnet build DockerizedCrud.csproj --configuration Release --no-restore'
            }
         }
   
        stage('Publish'){
             steps{
               sh 'dotnet publish DockerizedCrud.csproj --configuration Release -o publishfolder --no-restore'
             }
        }
    
    }
}