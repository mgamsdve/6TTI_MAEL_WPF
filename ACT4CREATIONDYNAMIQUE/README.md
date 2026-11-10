# ACT 4 — Création dynamique d'objets

Ouvrir `CreationDynamique.sln` dans Visual Studio sous Windows avec la charge de travail **Développement Desktop .NET**, puis lancer avec **F5** (.NET 8).

Les contrôles sont entièrement créés en C# dans `MainWindow.xaml.cs`. Le XAML contient uniquement la fenêtre vide.

- **Exercice 1** : grille 3 × 3, titre sur les trois colonnes, trois boutons, StackPanel vertical sur deux cellules avec un TextBlock et un TextBox, puis ComboBox avec deux éléments.
- **Exercice 2 : ?** : grille 4 × 4, tableaux `ColumnDefinition[]` et `RowDefinition[]`, matrice `TextBlock[,]`. Un événement `MouseDown` remplace le texte cliqué par `X`.
- **Exercice 2 : animaux** : même grille, avec seize emojis tirés au hasard dans une `List<string>`. Chaque emoji est retiré de la liste après son tirage pour éviter les répétitions. Le clic remplace également l'animal par `X`.

WPF nécessite Windows pour exécuter l'application. Depuis macOS, on peut compiler le projet, mais pas lancer son interface WPF.
