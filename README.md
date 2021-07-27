# github-action-in-csharp-samples

This Repository contains a sample GitHub action written in C#. GitHub Actions support two variations of app development, either

1. JavaScript 
2. Docker container (any app that runs on Docker)

Since .NET is not natively supported by GitHub Actions, the .NET app needs to be containerized. 

Step 1 - We will be creating a simple .Net SDK 5.0 C# project. Can use .Net Core too, in which case the Dockerfile would need changing. This would contain the crux of what the GitHub action is trying to achieve. 

Step 2 - Next we create a Dockerfile to be able to containerise the .Net Application. In the Dockerfile we will be restoring Nuget packages, building and publishing the release executable and define the Entrypoint.

Step 3 - Define an action.yaml file which represents the inputs for the GitHub Action. For GitHub to recognize that the repository is a GitHub Action, you need to have an action.yml file at the root of the repository.

Step 4 - We then consume the Action that we have created in a GitHub workflow by creating a step that uses that action.

---
# EXAMPLE

```yaml

# This is a basic workflow to help you get started with csharp Actions

name: CI

on:
  # Triggers the workflow on push or pull request events but only for the main branch
  push:
    branches: [ main ]
  pull_request:
    branches: [ main ]
    
  workflow_dispatch:

jobs:  
  build:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v2
        with:
            repository: Maersk-Global/github-action-in-csharp-samples
            token: ${{ secrets.ADMIRAL_GITOPS }} # `ADMIRAL_GITOPS` is a secret that contains your PAT         
      -
        id: ghactions
        uses: ./
        with:          
          firstname: "Bat"
          lastname: "Man"
