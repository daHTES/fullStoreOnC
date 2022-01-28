﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {

        private readonly Book[] books = new[]
        {
            new Book 
            (1, 
                "ISBN 76768-98874", 
                "Скотт Оукс", 
                "ЭФФЕКТИВНЫЙ JAVA. ТЮНИНГ КОДА НА JAVA 8, 11", 
                "Программирование и тестирование обычно принято относить к разным профессиональным сферам. " +
                "Скотт Оукс — признанный эксперт по языку Java — " +
                "уверен, что если вы хотите работать с этим языком, то обязаны понимать, " +
                "как выполняется код в виртуальной машине Java, и знать, " +
                "какие настройки влияют на производительность.",
                1299
            ),
            new Book 
            (2, 
                "ISBN 79068-76654",
                "Дэн Вандеркам",
                "ЭФФЕКТИВНЫЙ TYPESCRIPT: 62 СПОСОБА УЛУЧШИТЬ КОД",
                "«Эффективный TypeScript» необходим тем, кто уже имеет опыт работы с JavaScript. " +
                "Цель этой книги - не научить пользоваться инструментами, " +
                "а помочь повысить профессиональный уровень. ",
                759
            ),
            new Book 
            (3, 
                "ISBN 14768-44334",
                "Итан Браун",
                "ВЕБ-РАЗРАБОТКА С ПРИМЕНЕНИЕМ NODE И EXPRESS",
                "JavaScript - самый популярный язык написания клиентских сценариев. " +
                "Это основополагающая технология для создания всевозможных анимаций и переходов. " +
                "Без JavaScript практически невозможно обойтись, если требуется " +
                "добиться современной функциональности на стороне клиента.",
                859
            ),
            new Book 
            (4,
                "ISBN 34766-14934",
                "Билл Любанович",
                "ПРОСТОЙ PYTHON. СОВРЕМЕННЫЙ СТИЛЬ ПРОГРАММИРОВАНИЯ",
                "«Простой Python» познакомит вас с одним из самых популярных языков программирования. " +
                "Книга идеально подойдет как начинающим, так и опытным программистам, " +
                "желающим добавить Python к списку освоенных языков.",
                1139
            ),
            new Book 
            (5,
                "ISBN 34789-00934",
                "Лейн Кэмпбелл",
                "БАЗЫ ДАННЫХ. ИНЖИНИРИНГ НАДЕЖНОСТИ",
                "В сфере IT произошла настоящая революция — с инфраструктурой стали работать как с кодом. " +
                "Этот процесс создает не только новые проблемы, но и возможности для обеспечения безотказной работы баз данных. " +
                "Авторы подготовили это практическое руководство для всех, кто желает влиться в сообщество " +
                "современных инженеров по обеспечению надежности баз данных (database reliability engineers, DBRE).",
                879
                ),
            new Book 
            (6,
                 "ISBN 16689-01934",
                 "Ния Нархид",
                 "APACHE KAFKA. ПОТОКОВАЯ ОБРАБОТКА И АНАЛИЗ ДАННЫХ",
                 "При работе любого enterprise-приложения образуются данные: " +
                "это файлы логов, метрики, информация об активности пользователей, исходящие сообщения " +
                "и т. п. Правильные манипуляции над всеми этими данными не менее важны, чем сами данные.",
                 709
             ),
            new Book 
            (7,
                "ISBN 90089-01984",
                "Дэвид Скляр",
                "PHP. РЕЦЕПТЫ ПРОГРАММИРОВАНИЯ",
                "ретье издание пой популярной книги представляет собой подборку ютовых решений наиболее распространенных " +
                "задач на языке PНP. Изложен материал, интересный каждому разработчику: базовые типы данных, " +
                "операции с ними, файлы cookie, функции PНP, аутентификация пользователей, работа со слоями, проблемы безопасности, " +
                "ускорение действия программ, работа в сети, создание графических изображений, обработка ошибок, отладка сценариев и написание тестов.",
                879
            ),
            new Book 
            (8,
                "ISBN 97889-91954",
                "Джеффри Фридл",
                "РЕГУЛЯРНЫЕ ВЫРАЖЕНИЯ",
                "Вы никогда не пользовались регулярными выражениями? Откройте мир regex, и станьте профессионалом, способным эффективно работать с " +
                "данными в Java, JavaScript, C, C++, C#, Perl, Python, Ruby, PHP и других языках программирования.",
                859
             ),
            new Book 
            (9,
                "ISBN 68589-34954",
                "Джефф Паттон",
                "ПОЛЬЗОВАТЕЛЬСКИЕ ИСТОРИИ",
                "Пользовательские истории - это метод описания требований к разрабатываемому продукту. Автор доступно и интересно рассказывает, " +
                "как правильно использовать данную технику, чтобы сфокусироваться на поставленной задаче и пожеланиях клиента, а не распыляться на реализации второстепенных функций.",
                619
            ),
            new Book
            (10,
                "ISBN 77581-44654",
                "Герберт Шилдт",
                "C++. ПОЛНОЕ РУКОВОДСТВО",
                "В этом, ставшем уже классическим, издании книги полностью описаны и проиллюстрированы все ключевые слова, функции, классы и свойства языка С++, соответствующие стандарту ANSI/ISO. " +
                "Информацию, изложенную в книге, можно использовать во всех современных средах программирования.",
                1347
             ),
            new Book 
            (11,
                "ISBN 11341-44654",
                "Роберт Седжвик",
                "АЛГОРИТМЫ НА C++",
                "Роберт Седжвик тщательно переписал, существенно расширил и обновил свою популярную книгу «Алгоритмы на C++», чтобы получилось современное и исчерпывающее " +
                "описание важных фундаментальных алгоритмов и структур данных.",
                2590
            ),
            new Book 
            (12,
                "ISBN 33455-44654",
                "Стивен Прата",
                "ЯЗЫК ПРОГРАММИРОВАНИЯ C++. ЛЕКЦИИ И УПРАЖНЕНИЯ",
                "Эта книга представляет собой тщательно проверенный, качественно составленный и один из лучших учебников по языку программирования " +
                "C++ (C++11) для программистов и разработчиков.",
                1319
            ),
            new Book 
           (13,
                "ISBN 99400-55659",
                "Энтони Уильямс",
                "C++. ПРАКТИКА МНОГОПОТОЧНОГО ПРОГРАММИРОВАНИЯ",
                "Язык С++ выбирают, когда надо создать по-настоящему молниеносные приложения. А качественная конкурентная обработка " +
                "сделает их еще быстрее. Новые возможности С++17 позволяют использовать всю мощь многопоточного программирования, чтобы с легкостью решать задачи " +
                "графической обработки, машинного обучения и др. ",
                1859
            )

        };

        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            var foundBooks = from book in books join bookID in bookIds on book.ID equals bookID select book;

            return foundBooks.ToArray();
        }

        public Book[] GetAllIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }

        public Book[] GetAllTitleOrAuthor(string query)
        {
            return books.Where(book => book.Author.Contains(query)
                                    || book.Title.Contains(query))
                                       .ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(book => book.ID == id);
        }
    }
}
