class Songs:
    def __init__(self, lyrics):
       self.lyrics = lyrics

    def singMeASong(self):
        for i in range(len(lyrics)):
            print(lyrics[i])

   
lyrics = ["Find light in the beautiful sea",
 "I choose to be happy", "You and I, you and I", "We're like diamonds in the sky"]  
song = Songs(lyrics) 
song.singMeASong()

