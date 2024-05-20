pipeline {
    agent any
	
    stages {
        stage('Checkout') {
            steps {
                // Checkout code from Git
                git url: 'https://github.com/munawersheikh/practicewebapi', branch: 'main'
            }
        }

        stage('Build Solution') {
            steps {
                script {
                    echo "Starting build process for solution..."
                    try {
                        sh 'dotnet build PracticeJenkinsAndWebApi.sln'
                        echo "Build completed successfully."
                    } catch (Exception e) {
                        echo "Build failed with error: ${e.message}"                        
                    }
                }
            }
        }
    }

    post {
        failure {
            mail to: 'your-email@example.com',
                 subject: "Build Failed in Jenkins: ${currentBuild.fullDisplayName}",
                 body: "Build failed. Please check Jenkins for details."
        }
    }
}