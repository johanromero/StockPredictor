﻿<div class="box">
    <table class="table is-hoverable is-striped is-fullwidth">
        <thead>
            <tr>
                <th id="date"><a asp-action="History" asp-controller="User" asp-route-sort="CreationDate"><abbr title="Creation Date">Date</abbr></a></th>
                <th id="companyName"><a asp-action="History" asp-controller="User" asp-route-sort="CompanyName">Company Name</a></th>
                <th id="ticker"><a asp-action="History" asp-controller="User" asp-route-sort="Ticker"><abbr title="Ticker">Tkr</abbr></a></th>
                <th id="1d"><a asp-action="History" asp-controller="User" asp-route-sort="OneDayPred"><abbr title="One Day">1d</abbr></a></th>
                <th id="1w"><a asp-action="History" asp-controller="User" asp-route-sort="OneWeekPred"><abbr title="One Week">1w</abbr></a></th>
                <th id="1mo"><a asp-action="History" asp-controller="User" asp-route-sort="OneMonthPred"><abbr title="One Month">1mo</abbr></a></th>
                <th id="3mo"><a asp-action="History" asp-controller="User" asp-route-sort="ThreeMonthPred"><abbr title="Three Month">3mo</abbr></a></th>
                <th id="1yr"><a asp-action="History" asp-controller="User" asp-route-sort="OneYearPred"><abbr title="One Year">1yr</abbr></a></th>
            </tr>
        </thead>
        <tbody>
            @foreach (var item in Model.Predictions)
         {
                <tr>
                    <td>@item.CreationDate.ToLocalTime()</td>
                    <td>@item.CompanyName</td>
                    <td>@item.Ticker</td>
                    <td>@String.Format("{0:C2}", item.OneDayPred)</td>
                    <td>@String.Format("{0:C2}", item.OneWeekPred)</td>
                    <td>@String.Format("{0:C2}", item.OneMonthPred)</td>
                    <td>@String.Format("{0:C2}", item.ThreeMonthPred)</td>
                    <td>@String.Format("{0:C2}", item.OneYearPred)</td>
                </tr>
            }
        </tbody>
    </table>
</div>

@section Scripts
{
    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.2.0.min.js"></script>
}