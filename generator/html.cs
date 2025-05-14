/*
using System;

public async Task HTMLGenerator(string FileTag, NewsAPIService newAPI, UserInterfacesErreur Error) {
    string html =$@"
        <!DOCTYPE html>
        <html lang='fr'>
        <head>
            <meta charset='UTF-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            <title>{FileTag}</title>
            <link rel='stylesheet' href='../style/style.css'>
        </head>
        <body>
            <div class='container'>
        ";

        html += @"
            </div>
        </body>
        </html>
        ";

        error.ErreurDirectoryPath("output");
        if (error.ErreurFileExists($"output/{fileName}.html"))
        {
            File.WriteAllText($"output/{fileName}.html", html);
            Console.WriteLine("Fichier créer avec succès");
        }
}

*/