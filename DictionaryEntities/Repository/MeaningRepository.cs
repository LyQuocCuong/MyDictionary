using DictionaryDto;
using DictionaryEntities.Entity.Context;
using DictionaryEntities.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEntities.Repository
{
    public class MeaningRepository : AbstractRepository<MEANING>
    {
        public MeaningRepository(DictionaryRepository repository) : base(repository)
        {

        }

        public List<MeaningDto> FindMeaningListHaveExample(Guid wordId)
        {
            List<MeaningDto> meaningList = new List<MeaningDto>();
            try
            {
                if (DataSet.FirstOrDefault(m => m.WORD_ID == wordId && !m.DELETED && !m.WORD.DELETED) != null)
                {
                    meaningList.AddRange(DataSet.Where(m => m.WORD_ID == wordId && !m.DELETED && !m.WORD.DELETED)
                                                .OrderBy(m => m.TEXT)
                                                .AsEnumerable()
                                                .Select(m => new MeaningDto()
                                                {
                                                    MeaningId = m.ID,
                                                    WordId = m.WORD_ID,
                                                    WordText = m.WORD.TEXT,
                                                    MeaningText = m.TEXT,
                                                    ExampleList = Repository.EXAMPLE.FindExampleList(m.ID),
                                                })
                                        );
                }
            }
            catch(Exception ex)
            {

            }
            return meaningList;
        }

        public MeaningDto FindDetailMeaning(Guid meaningId)
        {
            MeaningDto meaningDto = new MeaningDto();
            MEANING meaning = DataSet.FirstOrDefault(m => m.ID == meaningId && !m.DELETED);
            if (meaning != null)
            {
                meaningDto.MeaningId = meaning.ID;
                meaningDto.MeaningText = meaning.TEXT;
                meaningDto.ExampleList = Repository.EXAMPLE.FindExampleList(meaning.ID);
            }
            return meaningDto;
        }

        public void CreateMeaning(MeaningDto meaningDto)
        {
            MEANING newMeaning = new MEANING()
            {
                ID = Guid.NewGuid(),
                WORD_ID = meaningDto.WordId,
                TEXT = meaningDto.MeaningText,
            };
            DataSet.Add(newMeaning);
            Repository.SaveChanges();
        }

        public void UpdateMeaning(MeaningDto meaningDto)
        {
            MEANING meaning = DataSet.FirstOrDefault(m => m.ID == meaningDto.MeaningId);
            if (meaning != null)
            {
                meaning.TEXT = meaningDto.MeaningText;
                Repository.SaveChanges();
            }
        }

        public void DeleteMeaning(Guid meaningId)
        {
            MEANING meaning = DataSet.FirstOrDefault(m => m.ID == meaningId);
            if (meaning != null)
            {
                meaning.DELETED = true;
                Repository.SaveChanges();
            }
        }

        public ChallengeDto CreateQuestion()
        {
            ChallengeDto challengeDto = new ChallengeDto();
            MEANING rightAnswer = Repository.Context.MEANING
                                    .Where(m => !m.DELETED)
                                    .OrderBy(r => Guid.NewGuid())
                                    .FirstOrDefault();
            challengeDto.RightAnswerId = rightAnswer.WORD_ID;
            challengeDto.QuestionText = rightAnswer.WORD.TEXT;
            challengeDto.TypeWordText = rightAnswer.WORD.TYPE_WORD.TYPE_TEXT;
            challengeDto.Pronounce = rightAnswer.WORD.PRONOUNCE;
            challengeDto.Sound = rightAnswer.WORD.SOUND;
            challengeDto.AnswersList.Add(new AnswerDto()
            {
                AnswerId = rightAnswer.WORD_ID,
                AnswerText = rightAnswer.TEXT,
            });
            challengeDto.AnswersList
                .AddRange(Repository.Context.MEANING
                                    .Where(m => !m.DELETED && m.WORD_ID != rightAnswer.WORD_ID)
                                    .OrderBy(r => Guid.NewGuid())
                                    .Take(3)
                                    .Select(m => new AnswerDto()
                                    {
                                        AnswerId = m.WORD_ID,
                                        AnswerText = m.TEXT,
                                    }));
            if (rightAnswer.EXAMPLE_LIST.FirstOrDefault(e => !e.DELETED) != null)
            {
                challengeDto.ExampleList.AddRange(
                    rightAnswer.EXAMPLE_LIST
                               .Where(e => !e.DELETED)
                               .Select(e => new ExampleDto()
                               {
                                   ExampleText = e.TEXT
                               })); ;
            }
            var rand = new Random();
            challengeDto.AnswersList.Sort((a, b) => rand.Next(-1, 2));
            return challengeDto;
        }

    }
}
