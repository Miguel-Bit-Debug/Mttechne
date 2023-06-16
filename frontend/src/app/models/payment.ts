export class Payment {
  public description: string;
  public paymentDate: Date;
  public paymentType: number;
  public paymentAmount: number;

  constructor(description: string, paymentDate: Date,  paymentType: number, paymentAmount: number) {
    this.description = description;
    this.paymentDate = paymentDate;
    this.paymentType = paymentType;
    this.paymentAmount = paymentAmount;
  }
}
