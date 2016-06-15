@echo off
echo Subiendo archivos a GIT

git config --global user.email "yasha_i@hotmail.com"
git config --global user.name "ricardoaijon"
git init
git add .
git commit -m "adding files C#"
git remote add origin https://github.com/ricardoaijon/C-BasicExamples.git
git push -u origin master
pause