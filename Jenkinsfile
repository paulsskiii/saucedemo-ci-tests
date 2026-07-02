pipeline {
    agent any
 
    stages {
        stage('Checkout') {
            steps { checkout scm }
        }
        stage('Restore') {
            steps { bat 'dotnet restore' }
        }
        stage('Build') {
            steps { bat 'dotnet build --no-restore -c Release' }
        }
        stage('Test') {
            steps {
                bat 'dotnet test --no-build -c Release --logger "nunit;LogFileName=results.xml" --results-directory TestResults'
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
