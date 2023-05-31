import { OpenaiService } from './../services/openai.service';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {
     
      constructor(private openaiService: OpenaiService) {
      }
      //private model = "text-davinci-003";
      //private prompt : string ='';
      leetCodeUrl: string ='';
      isLoading: boolean = false;
      result: string ='';
      selectedLanguage: string ='c#';
      languages: string[] = ['c#', 'javascript', 'typescript', 'python3'];
      btnSolveClicked() {
        
        console.log('btn Solved Clicked');

        this.isLoading = true;
        console.log(this.isLoading);

        // this.prompt=`Given a ${this.selectedLanguage} solution for the leetcode question below 
        //             Leet Code Question: ${this.leetCodeUrl} 
        //             ${this.selectedLanguage} Solution: `;
        // console.log(this.prompt);
        
        //must be in json format (with correct string format)
        //const data = '{ "url" :' + '"' + this.leetCodeUrl + '", "language":' + '"' + this.selectedLanguage + '"}';

        const data = {
          url: this.leetCodeUrl, 
          language: this.selectedLanguage 
        };

        console.log(data);

        //response from api must be in json format cause (application/json)
          this.openaiService.postData(data).subscribe(response => {
            console.log('response from openai*****');
            console.log(response);

            this.isLoading = false;
            const textarea = document.querySelector('textarea');

            if (textarea != null)
            textarea.value = response.choices[0].text;
            this.result = response.choices[0].text;

          }, error => {
            console.error(error);
          });
      }
      copyToClipboard() {
        navigator.clipboard.writeText(this.result);
      }
}
