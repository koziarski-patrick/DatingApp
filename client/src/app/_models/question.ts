import { Answer } from "./answer";
import { Survey } from "./survey";

export interface Question {
  questionID: number;
  surveyID: number;
  text: string;
  survey: Survey;
  answers: Answer[]; // Add this property
}
