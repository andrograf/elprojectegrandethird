import useFetch from './useFetch';

function DataDisplay() {
    const url = "https://api.calorieninjas.com/v1/nutrition?query=apple";
    const { data, loading, error } = useFetch(url);

    if (loading) return <img src={loadingGif} alt="poopies" />

    if (error) console.log(error);

    return (
        <div className="dataContainer">
            <h1>{data?.setup} : {data?.deliver }</h1>
        </div>
        )
}

export default DataDisplay;