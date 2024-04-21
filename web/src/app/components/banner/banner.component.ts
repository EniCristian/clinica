import { Component, Input } from '@angular/core';
import { BannerItem } from './banner-item';
import { CommonModule } from '@angular/common';
import { CommonsModule } from '../../common/commons.module';

@Component({
  selector: 'app-banner',
  standalone: true,
  imports: [CommonModule, CommonsModule],
  templateUrl: './banner.component.html',
  styleUrl: './banner.component.scss',
})
export class BannerComponent {
  @Input()
  input: BannerItem | undefined = undefined;
}
