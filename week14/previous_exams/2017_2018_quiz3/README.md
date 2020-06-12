# Quiz 3

## Question 1

You are given a dataset consisting of US 1/11/2016 Presidential Election Poll Results from various pollsters.

You are required to do the following:
1. Read the [2016election.csv](./2016election.csv) file
2. There are known swing states in the US whose vote are not decisive on a candidate (such as Florida), analyze a swing state:
    * Investigate polls month-by-month (beware the year!)
    * Each time a candidate was not the popular option that month but becomes the next month, increase the swing of that state and show the swinging months' data.
3. Pollsters have been graded in the dataset (from max A+ to min D, including A, A-, etc.), knowing that Donald J. Trump had won the election (US-wise), re-calculate the credibility of the pollsters (increase grade if they have guessed correctly, decrease otherwise) (20pts) and sort them from the most credible to least (15pts) (use adjpoll column).

**P.S.** adjpoll is just the raw poll data augmented with the historical data of that state.

**P.P.S.** It is common tradition in US elections to ask voters about who they voted for in the election day when they have just exited the voting area.
