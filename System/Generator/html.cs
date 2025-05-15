using System;

class HTML
{
    public void HTMLGenerator(string genre, string FileTag, string htmlcontent) {
        string html = $@"
            <!DOCTYPE html>
            <html lang='fr'>
            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>{FileTag}</title>
                <link rel='stylesheet' href='styles/{genre}.css'>
            </head>
            <body>
                <div class='container'>
            ";

        html += htmlcontent;

        html += @"
                </div>
            </body>
            </html>
            ";
        File.WriteAllText($"System/Generator/créations/{FileTag}.html", html);
    }
}