using System;

class HTML {
    public void HTMLGenerator(string genre, string fileName, string htmlContent)
    {
        string html =$@"
            <!DOCTYPE html>
            <html lang='fr'>
            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>{fileName}</title>
                <link rel='stylesheet' href='styles/{genre}.css'>
            </head>
            <body>
                <div class='container'>
            ";

            html += htmlContent;

            html += @"
                </div>
            </body>
            </html>
            ";
            File.WriteAllText($"System/Generator/créations/{fileName}.html", html);
    }
}