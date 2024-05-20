pipeline {
    agent {
        docker {
            image 'jenkins-dotnet:latest'
            args '-u root'
        }
    }

    triggers {
        // Trigger the pipeline when there is a push to the repository
        pollSCM('H/5 * * * *')
    }

    stages {
        stage('Checkout') {
            steps {
                // Checkout code from Git
                git url: 'https://your-git-repository-url.git', branch: 'DEV'
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
                        
                        mail to: 'your-email@example.com',
                             subject: "Build Failed in Jenkins: ${currentBuild.fullDisplayName}",
                             body: "Build failed with error: ${e.message}. Please check Jenkins for details."
                        
                        currentBuild.result = 'FAILURE'
                        
                        throw e
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
