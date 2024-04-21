import { Component } from '@angular/core';
import { CommonsModule } from '../../../common/commons.module';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [CommonsModule],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.scss',
})
export class FooterComponent {
  currentYear = new Date().getFullYear();
}
