pipeline {
    agent any
    stages {
        stage('Checkout') {
            steps { checkout scm }
        }
        stage('Restore') {
            steps { sh 'dotnet restore' }
        }
        stage('Build') {
            steps { sh 'dotnet build --no-restore -c Release' }
        }
        stage('Test') {
            steps {
                sh 'dotnet test --no-build -c Release --logger "nunit;LogFileName=results.xml" --results-directory TestResults'
            }
        }
    }
    post {
        always {
            nunit testResultsPattern: 'TestResults/results.xml'
            cleanWs()
        }
    }
}