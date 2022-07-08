using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

// The code example shows how to implement a metronome that procedurally generates the click sounds via the OnAudioFilterRead callback.
// While the game is paused or the suspended, this time will not be updated and sounds playing will be paused. Therefore developers of music scheduling routines do not have to do any rescheduling after the app is unpaused

[RequireComponent(typeof(AudioSource))]
public class AudioTimer : GameBehaviour<AudioTimer>
{
    public double bpm = 120.0F;
    public float gain = 0.5F;
    public int signatureHi = 4;
    public int signatureLo = 4;
    public int bars = 4;
    private double nextTick = 0.0F;
    private float amp = 0.0F;
    private float phase = 0.0F;
    private double sampleRate = 0.0F;
    private int accent;
    private bool running = false;
    private int bar;
    private int currentBar;
    private int steps;

    int totalNotes = 0;
    public int currentBeat = 0;
    float noteFadeTime = 0.5f;
    bool ticked = false;
    void Start()
    {
        accent = signatureHi;
        double startTick = AudioSettings.dspTime;
        sampleRate = AudioSettings.outputSampleRate;
        nextTick = startTick * sampleRate;
        running = true;
        currentBar = 1;
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        if (!running)
            return;
        bar = bars * signatureHi;
        double samplesPerTick = sampleRate * 60.0F / bpm * 4.0F / signatureLo;
        double sample = AudioSettings.dspTime * sampleRate;
        int dataLen = data.Length / channels;
        int n = 0;
        while (n < dataLen)
        {
            float x = gain * amp * Mathf.Sin(phase);
            int i = 0;
            while (i < channels)
            {
                data[n * channels + i] += x;
                i++;
            }
            while (sample + n >= nextTick)
            {

                steps = steps != bars ? steps += 1 : 1;

                nextTick += samplesPerTick;
                amp = 1.0F;
                if (++accent > signatureHi)
                {
                    accent = 1;
                    amp *= 2.0F;
                    if (currentBeat == 4)
                    {
                        currentBeat = 1;
                        currentBar = currentBar != bars ? currentBar += 1 : 1;
                    }
                    else
                        currentBeat += 1;
                }
                ticked = true;
                Debug.Log("Tick: " + currentBar + "-" + currentBeat + "-" + accent +  " [" + steps + "]");
            }
            phase += amp * 0.3F;
            amp *= 0.993F;
            n++;
        }
    }

    private void Update()
    {
        if (ticked)
        {
            ticked = false;
            GameEvents.ReportAudioTick(currentBar, currentBeat, accent, steps);
        }
    }
}