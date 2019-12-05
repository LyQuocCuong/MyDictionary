using DictionaryDto;
using DictionaryEntities.Entity.Context;
using DictionaryEntities.Entity.Models;
using DictionaryHelper;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DictionaryEntities.Repository
{
    public class MeaningRepository : AbstractRepository<MEANING>
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(MeaningRepository));

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
                Logger.Error("Application Error " + ex);
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
            try
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
            catch(Exception ex)
            {
                Logger.Error("Application Error " + ex);
            }
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
            Random random = new Random();
            int indexQuestion = random.Next(0, CommonVariable.Max_Number_Answers);
            int maxLengthMeaning = DataSet.Where(m => !m.DELETED).Count();
            string strMeaningId = "";

            //create test
            while (challengeDto.AnswersList.Count() < CommonVariable.Max_Number_Answers)
            {
                Thread.Sleep(200);
                int skipNumber = random.Next(1, maxLengthMeaning);
                MEANING meaning = DataSet.Where(m => !m.DELETED)
                                             .OrderBy(m => Guid.NewGuid())
                                             .Skip(skipNumber)
                                             .Take(1)
                                             .FirstOrDefault();
                if (meaning != null && !strMeaningId.Contains(meaning.ID.ToString()))
                {
                    strMeaningId += meaning.ID.ToString() + "-";
                    if (challengeDto.AnswersList.Count() == indexQuestion)
                    {
                        challengeDto.Question.WordId = meaning.WORD_ID;
                        challengeDto.Question.WordText = meaning.WORD.TEXT;
                        challengeDto.Question.TypeWordText = meaning.WORD.TYPE_WORD.TYPE_TEXT;
                        challengeDto.Question.Pronounce = meaning.WORD.PRONOUNCE;
                        challengeDto.Question.Sound = meaning.WORD.SOUND;
                    }
                    challengeDto.AnswersList.Add(new AnswerDto()
                    {
                        WordId = meaning.WORD_ID,
                        MeaningId = meaning.ID,
                        MeaningText = meaning.TEXT,
                    });
                }
            }

            //find corrected answer
            foreach(AnswerDto answerDto in challengeDto.AnswersList)
            {
                if (answerDto.WordId == challengeDto.Question.WordId)
                {
                    answerDto.IsCorrected = true;
                }
            }

            return challengeDto;
        }

    }
}
