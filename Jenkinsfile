pipeline {
    agent any
    stages {
        stage('Nightly') {
            steps {
                sh 'dotnet restore'
                sh 'dotnet build --no-restore'
            }
        }
    }
}