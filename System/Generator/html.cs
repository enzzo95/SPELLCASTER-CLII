using System;

class HTML {
    public void HTMLGenerator(string FileTag) {
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
            File.WriteAllText($"System/Creation/{FileTag}.html", html);
    }
}



 