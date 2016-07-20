namespace Response

type FaceRectangle = {
        height: int;
        left : int;
        top : int;
        width: int;
        }
    

    type Scores = {
        anger: double;
        contempt: double;
        disgust: double;
        fear: double;
        happiness: double;
        neutral: double;
        sadness: double;
        surprise: double;
        }

    type EmotionResponce = {
        faceRectangle : FaceRectangle;
        scores : Scores;
        }

