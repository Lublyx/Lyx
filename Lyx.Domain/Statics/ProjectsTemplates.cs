namespace Lyx.Domain.Statics;

public static class ProjectsTemplates
{
    public static class Python
    {
        public const string Native = @"
print('Hello world!')
";

        public const string Flask = @"
from flask import Flask
app = Flask(__name__)

@app.route('/')
def index():
  return 'Hello World!'

if __name__ == '__main__':
  app.run(debug=True)
";

    public const string PyGame = @"
import pygame
from pygame.locals import *

class App:
    '''Create a single-window app with multiple scenes.'''

    def __init__(self):
        '''Initialize pygame and the application.'''
        pygame.init()
        flags = RESIZABLE
        App.screen = pygame.display.set_mode((640, 240), flags)

        App.running = True

def run(self):
    '''Run the main event loop.'''
    while App.running:
        for event in pygame.event.get():
            if event.type == QUIT:
                App.running = False
    pygame.quit()

if __name__ == '__main__':
    App().run()
";
    }

    public static class Html
    {
        public const string Native = @"
<!DOCTYPE html>
<html lang='fr'>
  <head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <meta http-equiv='X-UA-Compatible' content='ie=edge'>
    <title>My Website</title>
    <link rel='stylesheet' href='./style.css'>
    <link rel='icon' href='./favicon.ico' type='image/x-icon'>
  </head>
  <body>
    <main>
        <h1>Welcome to My Website</h1>  
    </main>
  </body>
</html>
";
    }
}