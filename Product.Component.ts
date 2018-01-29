<p *ngIf="!Items"><em>Loading...</em></p>
<table class='table dtTable' *ngIf="Items" >
  <thead>
    <tr>
      <th>Id</th>
      <th>Code</th>
      <th>Name</th>
    </tr>
  </thead>
  <tbody>
    <tr *ngFor="let x of Items">
      <td>{{ x.productId }}</td>
      <td>{{ x.productCode }}</td>
      <td>{{ x.productName }}</td>
    </tr>
  </tbody>
</table>
