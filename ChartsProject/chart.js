class SimpleChart {
  constructor(canvasId, data) {
    this.canvas = document.getElementById(canvasId);
    this.ctx = this.canvas.getContext("2d");
    this.data = data;
    this.width = this.canvas.width;
    this.height = this.canvas.height;
  }

  clear() {
    this.ctx.clearRect(0, 0, this.width, this.height);
  }

  drawAxes() {
    const ctx = this.ctx;

    ctx.beginPath();
    ctx.moveTo(40, 10);
    ctx.lineTo(40, this.height - 30);
    ctx.lineTo(this.width - 10, this.height - 30);
    ctx.stroke();
  }

  drawBarChart() {
    this.clear();
    this.drawAxes();

    const ctx = this.ctx;
    const max = Math.max(...this.data);
    const barWidth = (this.width - 60) / this.data.length;

    this.data.forEach((value, i) => {
      const barHeight = (value / max) * (this.height - 50);

      ctx.fillRect(
        40 + i * barWidth,
        this.height - 30 - barHeight,
        barWidth - 10,
        barHeight
      );
    });
  }

  drawLineChart() {
    this.clear();
    this.drawAxes();

    const ctx = this.ctx;
    const max = Math.max(...this.data);
    const stepX = (this.width - 60) / (this.data.length - 1);

    ctx.beginPath();

    this.data.forEach((value, i) => {
      const x = 40 + i * stepX;
      const y = this.height - 30 - (value / max) * (this.height - 50);

      if (i === 0) ctx.moveTo(x, y);
      else ctx.lineTo(x, y);
    });

    ctx.stroke();
  }
}
// Function to create and display the chart based on user input. Connect UI to Library
function createChart() {
  const input = document.getElementById("dataInput").value;
  const type = document.getElementById("chartType").value;

  const data = input.split(",").map(Number);

  const chart = new SimpleChart("chartCanvas", data);

  if (type === "bar") chart.drawBarChart();
  if (type === "line") chart.drawLineChart();
}