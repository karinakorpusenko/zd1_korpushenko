using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd2_3
{

    class PlayList
    {
        private List<Song> list;
        private int currentIndex;

        public PlayList()
        {
            list = new List<Song>();
            currentIndex = 0;
        }

        public Song CurrentSong()
        {
            if (list.Count > 0)
                return list[currentIndex];
            else
                throw new IndexOutOfRangeException(
                    "Невозможно получить текущую аудиозапись для пустого плейлиста!");
        }
        public void AddSong(Song song)
        {
            list.Add(song);
        }

        // Перегруженный метод для добавления песни с параметрами
        public void AddSong(string author, string title, string filename)
        {
            Song song = new Song { Author = author, Title = title, Filename = filename };
            list.Add(song);
        }
        public void NextSong()//следующая песня
        {
            if (currentIndex < list.Count - 1)
                currentIndex++;
           
        }

        public void PreviousSong()//предыдущая запись
        {
            if (currentIndex > 0)
                currentIndex--;
           
        }

        public void GoToSong(int index)// по индексу
        {
            if (index >= 0 && index < list.Count)
                currentIndex = index;
          
        }

        public void GoToStart()//в начало
        {
            currentIndex = 0;
        }

       

        public void RemoveSong(Song song)//удалить
        {
            int index = list.IndexOf(song);
            if (index != -1)
            {
                list.RemoveAt(index);
                if (currentIndex >= list.Count) currentIndex = list.Count - 1; // Обновляем индекс
            }
        }

        public void ClearPlaylist()//очистить
        {
            list.Clear();
            currentIndex = 0;
        }
    }
}
